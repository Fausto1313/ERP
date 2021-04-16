<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ubicaciones2.aspx.cs" Inherits="ubicaciones2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
       <br />
     <nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#">Brand</a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li ><a href="#"  data-toggle="modal" data-target="#myModal">Nuevo Dispositivo   <span class="sr-only">(current)</span></a></li>
        <li><!--Inicio de ]Modal

            <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">
  Cliente Nuevo
</button>

            fin de modal-->
        </li>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="#">Action</a></li>
            <li><a href="#">Another action</a></li>
            <li><a href="#">Something else here</a></li>
            <li role="separator" class="divider"></li>
            <li><a href="#">Separated link</a></li>
            <li role="separator" class="divider"></li>
            <li><a href="#">One more separated link</a></li>
          </ul>
        </li>
      </ul>
       <div class="navbar-form navbar-left">
        <div class="form-group">
              <input type="text" runat="server" class="form-control"  placeholder="Nombre a Buscar">
            <button type="submit" class="btn btn-info glyphicon glyphicon-search">Buscar</button>
        </div>
       
      </div>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav> 
   <br />

      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="ID_Seccion" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="OnPageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ID_Seccion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID_Seccion" SortExpression="ID_Seccion">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="descripcion" SortExpression="Descripcion">
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
            <asp:BoundField DataField="ID_Cliente" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID_Cliente" SortExpression="ID_Cliente">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
      
      <asp:BoundField DataField="NO_IP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="NO_IP" SortExpression="NO_IP">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar">
                </asp:buttonField>

        <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar ">
                </asp:buttonField>
                
                       
                
        </Columns>
  
    </asp:GridView>
      <asp:Button ID="btnAdd" runat="server" OnClick="BtnAddClick" Text="Agregar Dispositivo" CssClass="btn btn-primary"/>
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
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="updModalLabel">Actualizar Registro</h3>
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
                                    <td> NDIP:
                            <asp:TextBox ID="txtNDIP" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td> Cliente:
                            <asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
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
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="delModalLabel">Eliminar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upDel" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            Desea Eliminar este registro?
                            <asp:HiddenField ID="hfidEvento" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnDelete" runat="server"  Text="Confirmar" CssClass="btn btn-danger" OnClick="BtnDelete_Click"  />
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
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel">Nuevo Dispositivo</h3>
                </div>
                  
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                 <tr>
                                    <td>idEvento : 
                                <asp:Label ID="txtID1"  runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>macID : 
                                <asp:TextBox ID="txtTipo1" placeholder="Tipo de Dispositivo" runat="server"></asp:TextBox>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Descripcion : 
                                <asp:TextBox ID="txtDescripcion1"  placeholde="Agrege la descripcion" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>Pais : 
                                <asp:TextBox ID="txtPais1"  placeholde="Pais" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>

                                    <td>Nivel:
                                <asp:TextBox ID="txtNivel1" placeholder="Nivel" runat="server"></asp:TextBox>
                                       
                                    </td>
                                </tr>
                                 <tr>
                                    <td>NDIP : 
                                <asp:TextBox ID="txtNDIP1"  placeholde="Agrege la descripcion" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Razon Social:
                                <asp:TextBox ID="txtRazonSocial1" placeholder="RazonSocial" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                                                                            
                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord" runat="server" OnClick="BtnAddRecordClick" Text="Confirmar " CssClass="btn btn-success"  />
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


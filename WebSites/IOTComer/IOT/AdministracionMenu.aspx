<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="AdministracionMenu.aspx.cs" Inherits="IOT_AdministracionMenu" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Menú del día</a>
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
<br />
    <div class="row">
        <div class="col-md-4">
            <asp:DropDownList runat="server" ID="Categoria" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Categoria_SelectedIndexChanged"/>
        </div>
        <div class ="col-md-4">
            <asp:DropDownList runat="server" ID="Subcategoria" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Subcategoria_SelectedIndexChanged" />
        </div>
    </div>
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
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Categoria" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Categoria" SortExpression="Categoria" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:buttonField  CommandName="updMenu" ButtonType="Button"  ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar Menu" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
           </asp:buttonField>
           <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
           </asp:buttonField>
        </Columns>
    </asp:GridView>
   <asp:Button ID="btnAdd" runat="server"  BorderColor=#0c4566 ValidationGroup="Agregar" OnClick="BtnAddClick" Text="Agregar Comida" CssClass="btn btn-success" Width="162px" />
               <asp:Button ID="btnAdd2" runat="server"  BorderColor=#0c4566 ValidationGroup="Agregar2" OnClick="BtnAddClick2" Text="Reasignar Comida" CssClass="btn btn-primary" Width="162px" />

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
                                    <label for="inputEmail3" class="col-md-3 control-label">ID</label>
                                <asp:Label ID="lblID"  runat="server"></asp:Label>
                                     </div>
                                 <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Nombre:</label>
                                <asp:TextBox ID="txtNombre"  placeholder="Nombre" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNombre" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtNombre" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                    <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Descripción:</label>
                                <asp:TextBox ID="txtDesc"  placeholder="Descripcion" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDesc" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtDesc" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" />
                                </div>

                                  <div class="form-group">
                                           <label for="input" class="col-md-3 control-label">Categoria:</label>
                                   <asp:DropDownList runat="server" ID="tipo2" BorderColor=#0c4566>
                                       <asp:ListItem>Seleccionar</asp:ListItem>
                                        <asp:ListItem>Sopa</asp:ListItem>
                                        <asp:ListItem>Plato Fuerte</asp:ListItem>
                                        <asp:ListItem>Aguas</asp:ListItem>
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
                                   <label for="input" class="col-md-3 control-label">Nombre:</label>
                                <asp:TextBox ID="txtNom1"  placeholder="Nombre" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNom1" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtNom1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="InsertFab"/>
                                </div>
                                    <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Descripción:</label>
                                <asp:TextBox ID="txtDesc1"  placeholder="Descripción" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDesc1" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator5" Display="Dynamic" controltovalidate="txtDesc1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="InsertFab"/>
                                    
                                </div>

                                 <div class="form-group">
                                 <label for="input" class="col-md-3 control-label">Categoria:</label>
                                   <asp:DropDownList runat="server" ID="Tipo" BorderColor=#0c4566>
                                         <asp:ListItem>Seleccionar</asp:ListItem>
                                        <asp:ListItem>Sopa</asp:ListItem>
                                        <asp:ListItem>Plato Fuerte</asp:ListItem>
                                        <asp:ListItem>Aguas</asp:ListItem>
                                       </asp:DropDownList>
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


     <!-- Inicia Modal Para Nuevo Registro-->
         <div id="addModal2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel2" aria-hidden="true">

                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel2" style="color:azure">Nuevo Menú</h3>
                </div>
                      <div class="form-group">
                <asp:UpdatePanel ID="upAdd2" class="form-group"  runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Categoria:</label>
                               <asp:DropDownList runat="server" ID="Reasignar" CssClass="form-control" BorderColor="#0c4566"  AutoPostBack="true" />
                               </div>
                            </table>
                                 </div>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord2" runat="server" OnClick="BtnAddRecordClick2" Text="Confirmar " CssClass="btn btn-success"  ValidationGroup="Res"/>
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

</asp:Content>


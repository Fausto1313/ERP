<%@ Page Language="C#" MasterPageFile="~/IOT/SiteLog.master"AutoEventWireup="true" CodeFile="Eventos2.aspx.cs" Inherits="Eventos" %>
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
      <a class="navbar-brand" href="#" style="color:azure">Catalogo de Eventos</a>
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

      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
            DataKeyNames="ID" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Evento" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Evento" SortExpression="Evento" >
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Comando" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Comando" SortExpression="Comando">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
               
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            <asp:BoundField DataField="Modelo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Modelo" SortExpression="Modelo">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
      
                <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar">
                </asp:buttonField>

        <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar ">
                </asp:buttonField>
        </Columns>
  
    </asp:GridView>
      <asp:Button ID="btnAdd" runat="server" OnClick="BtnAddClick" Text="Nuevo Evento" CssClass="btn btn-primary" ValidationGroup="validar"/>
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
                            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                                        <asp:Label runat="server" />
                                    </td>
                                  
                                </tr>
                                <tr>
                                    <td>Evento : 
                            <asp:TextBox ID="txtEvento" runat="server"></asp:TextBox>
                                        <asp:Label runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Comando:
                            <asp:TextBox ID="txtComando" runat="server"></asp:TextBox>
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                            <tr>
                                    <td>Descripcion:
                            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Modelo:
                           <asp:DropDownList runat="server" ID="modelos2"/>
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="BtnSave_Click" Text="Guardar" CssClass="btn btn-success" />
                            <button class="btn btn-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
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
                            <asp:HiddenField ID="hfID" runat="server" />
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
            <!--Finaliza Modal Para Eliminar-->

     <!-- Inicia Modal Para Nuevo Registro-->
           <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel">Nuevo Evento</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                       <ContentTemplate>
                        <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">ID</label>
                                <asp:TextBox ID="txtID1"  runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo id es obligatorio" ControlToValidate="txtID1" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtID1" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese Solo Texto!" />
                                     </div>
                                <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Evento:</label>
                                <asp:TextBox ID="txtEvento1"  placeholder="Agregar Evento" runat="server"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo evento es obligatorio" ControlToValidate="txtEvento1" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtEvento1" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                   <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Comando:</label>
                                <asp:TextBox ID="txtComando1"  placeholder="Agregar comando" runat="server"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo comando es obligatorio" ControlToValidate="txtComando1" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtComando1" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese Solo Texto!" />
                                    
                                </div>
                                 <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Descripcion:</label>
                                <asp:TextBox ID="txtDescripcion1"  placeholder="Agregar descripcion" runat="server"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripcion es obligatorio" ControlToValidate="txtDescripcion1" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtDescripcion1" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese Solo Texto!" />
                                    
                                </div>
                                         <div class="form-group">
                               <label for="input" class="col-md-3 control-label">Modelo</label>
                               <asp:DropDownList runat="server" ID="modelos" />

                                             </div>
                                    
                                </div>                                                     
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






















































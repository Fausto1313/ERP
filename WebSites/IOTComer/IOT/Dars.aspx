<%@ Page Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Dars.aspx.cs" Inherits="Dars" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Cat&aacute;logo DAR</a>
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
      <style>
        .icon-success {
    color:lawngreen;
     font-size:20px;
}
         .icon-actualizar {
    color:blue;
     font-size:20px;
}
  .icon-eliminar {
    color:red;
     font-size:20px;
}
         </style>
  <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catalogo se podra dar el alta de todos los dispositivos que se podran controlar en el sitio correspondiente.
  <p>
      INSTRUCCION: Para asignar el cliente al dispositivos deberas dar clic en el icono verde.
  </p>
    <p>
        Para mostrar la informacion en la tabla deberas selecciona el filtro
    </p>
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />


   <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center" ><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server" CssClass="body" >
          
     
          <ContentTemplate>
           <div class="row">
            <asp:Label runat="server" AssociatedControlID="Cli" CssClass="col-md-1 control-label">Cliente</asp:Label>
                <div class="col-md-1">
                    <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Cli" AutoPostBack="true"/>
                </div>
            </div>
              <br />
              Buscar:&nbsp;<asp:TextBox ID="txtSearch" style="text-align:center" runat="server" OnTextChanged="Search" AutoPostBack="true" ></asp:TextBox>
            
             <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
              AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="RISCEI" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField DataField="RISCEI" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="RISCEI" SortExpression="RISCEI" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripci&oacute;n" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="RazonSocial" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Cliente" SortExpression="ID_Cliente" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Modelo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Modelo" SortExpression="Modelo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
               <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-actualizar"></i>' />
               <%-- <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
               <asp:ButtonField CommandName="clienterecord" HeaderText="A&ntilde;adir Cliente" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-user icon-success"></i>' />
                <%--<asp:buttonField  CommandName="clienterecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" Text="Asignar" HeaderText="A&ntilde;adir Cliente" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
               <asp:ButtonField CommandName="delRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-eliminar"></i>' />
             <%-- <asp:buttonField  CommandName="delRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
              </asp:buttonField>--%>
        </Columns>
  
    </asp:GridView>
      <asp:Button ID="btnAdd" runat="server" OnClick="BtnAddClick" ValidationGroup="agregar" Text="Agregar Dar" CssClass="btn btn-success" BorderStyle="Solid" Width="162px"/>
            </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
    </div>
    <div>
                  <a class="btn btn-danger" href="CatalogoDi.aspx" runat="server" role="button">Volver</a>
                </div>
     <!-- Edit Modal Starts here -->
            <div id="updModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">

                            <table class="table">
                                <tr>
                                    <td>RISCEI : 
                            <asp:Label ID="txtRISCEI" runat="server" BorderColor=#0c4566></asp:Label>
                                    </td>
                                  
                                </tr>
                              
                                <tr>
                                    <td>Descripci&oacute;n:
                            <asp:TextBox ID="txtDescripcion" runat="server" BorderColor=#0c4566></asp:TextBox>

                            <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtDescripcion" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9.]*$" errormessage="Ingrese solo texto!"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripci&oacute;n es obligatorio" ControlToValidate="txtDescripcion" ForeColor="Red" ValidationGroup="InsertFab" >
                            </asp:RequiredFieldValidator>   
                                          
                                            
                                        <asp:Label runat="server" />
                                    </td>
                                </tr>
                            <tr>
                                    <td>Modelo:
                                        <asp:DropDownList runat="server" ID="Modelo2" BorderColor=#0c4566 />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Modelo es obligatorio" ControlToValidate="Modelo2" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>    
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="BtnSave_Click" Text="Guardar" CssClass="btn btn-success"  ValidationGroup="InsertFab" />
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
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="delModalLabel" style="color:azure">Eliminar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upDel" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            Desea Eliminar este registro?
                            <asp:HiddenField ID="hfRISCEI" runat="server" />
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
    <!---->
      <!-- Inicia Modal Para Nuevo Registro-->
            <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">

                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="addModalLabel" style="color:azure">Nuevo Dispositivo</h3>
                </div>
                  
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                
                                <tr>
                                    <td>RISCEI: 
                                <asp:TextBox ID="txtTipo1" placeholder="RISCEI" runat="server" BorderColor=#0c4566></asp:TextBox>
                                         
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo RISCEI es obligatorio" ControlToValidate="txtTipo1" ForeColor="Red" ValidationGroup="groupInsert" >
                                        </asp:RequiredFieldValidator>    
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator7" Display="Dynamic" controltovalidate="txtTipo1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9.]*$"/>   
                                    </td>
                                </tr>
                                <tr>
                                    <td>Descripci&oacute;n : 
                                <asp:TextBox ID="txtDescripcion1"  placeholder="Descripci&oacute;n" runat="server" BorderColor=#0c4566></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripci&oacute;n es obligatorio" ControlToValidate="txtDescripcion1" ForeColor="Red" ValidationGroup="groupInsert">
                                            </asp:RequiredFieldValidator> 
                                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtDescripcion1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9.]*$" errormessage="Ingrese solo texto !"/>
                                           
                                    </td>
                                </tr>
                                
                                   <tr>
                                    <td>Modelo:
                                    <asp:DropDownList runat="server" ID="Modelo" BorderColor=#0c4566 />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Modelo es obligatorio" ControlToValidate="Modelo" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>    
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
       <div id="updModalc" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="updModalLabel2" style="color:azure">Actualizar Registro Cliente</h3>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table">
                                <tr>
                                    <td>RISCEI : 
                            <asp:Label ID="lblRisc1" runat="server"></asp:Label>
                                    </td>                                 
                                </tr>                              
                                <tr>
                                    <td>Cliente:
                                    <asp:DropDownList runat="server" ID="Clientes" BorderColor=#0c4566 />
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>                          
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResultt" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="Button1" runat="server" ValidationGroup="Agregar" OnClick="BtnSave_ClickS" Text="Guardar" CssClass="btn btn-success" />
                            <button  class="btn btn-outline-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
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
                        <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                    </Triggers>
                </asp:UpdatePanel>
                     </div>
                    </div>
            </div>
    <!-- FIN MODAL ELIMINAR -->

</asp:Content>


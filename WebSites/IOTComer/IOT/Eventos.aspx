<%@ Page Language="C#" MasterPageFile="~/IOT/SiteLog.master"AutoEventWireup="true" CodeFile="Eventos.aspx.cs" Inherits="Eventos" %>
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
      <a class="navbar-brand" href="#" style="color:azure">Catálogo de Eventos</a>
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
    color: red;
     font-size:20px;
}
         .icon-actualizar {
    color:blue;
     font-size:20px;
}
    </style>
      <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catalogo se podra dar el alta  todos los eventos o acciones de los dispositivos.
  
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
              Buscar:&nbsp;<asp:TextBox ID="txtSearch" style="text-align:center" runat="server" OnTextChanged="Search" AutoPostBack="true" ></asp:TextBox>
            <br />
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
            DataKeyNames="ID" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Evento" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Evento" SortExpression="Evento" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Comando" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Comando" SortExpression="Comando" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripción" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
               
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            <asp:BoundField DataField="Modelo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Modelo" SortExpression="Modelo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
      <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-actualizar"></i>' />
                <%--<asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>

        
        </Columns>
  
    </asp:GridView>
      <asp:Button ID="btnAdd" runat="server" BorderColor=#0c4566 OnClick="BtnAddClick" Text="Nuevo Evento" ValidationGroup="Agregar" CssClass="btn btn-success" Width="162px"/>
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
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">

                            <table class="table">
                                <tr>
                                    <td>ID : 
                            <asp:Label ID="txtID" runat="server" BorderColor=#0c4566></asp:Label>
                                        <asp:Label runat="server" />
                                    </td>
                                  
                                </tr>
                                <tr>
                                    <td>Evento : 
                            <asp:TextBox ID="txtEvento" runat="server" BorderColor=#0c4566></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo evento es obligatorio" ControlToValidate="txtEvento" ForeColor="Red" ValidationGroup="updateEvent">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator5" Display="Dynamic" controltovalidate="txtEvento" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s/0-9]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="updateEvent"/>
                                        <asp:Label runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Comando:
                            <asp:TextBox ID="txtComando" runat="server" BorderColor=#0c4566></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo comando es obligatorio" ControlToValidate="txtComando" ForeColor="Red" ValidationGroup="updateEvent">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator6" Display="Dynamic" controltovalidate="txtComando" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="updateEvent"/>
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                            <tr>
                                    <td>Descripción:
                            <asp:TextBox ID="txtDescripcion" runat="server" BorderColor=#0c4566></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDescripcion" ForeColor="Red" ValidationGroup="updateEvent">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator7" Display="Dynamic" controltovalidate="txtDescripcion" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s/0-9 _-]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="updateEvent"/>
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Modelo:
                           <asp:DropDownList runat="server" ID="modelos2" BorderColor=#0c4566/>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="Seleccione un Modelo!" ControlToValidate="modelos2" ForeColor="Red" ValidationGroup="updateEvent">
                                           </asp:RequiredFieldValidator>
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server"  OnClick="BtnSave_Click" Text="Guardar" CssClass="btn btn-success" ValidationGroup="updateEvent"/>
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

     <!-- Inicia Modal Para Nuevo Registro-->
           <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel" style="color:azure">Nuevo Evento</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                       <ContentTemplate>
                        <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">ID</label>
                                <asp:TextBox ID="txtID1"  runat="server" BorderColor=#0c4566></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo id es obligatorio" ControlToValidate="txtID1" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtID1" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese Solo Texto!" />
                                     </div>
                                <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Evento:</label>
                                <asp:TextBox ID="txtEvento1"  placeholder="Evento" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo evento es obligatorio" ControlToValidate="txtEvento1" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtEvento1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s/]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                   <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Comando:</label>
                                <asp:TextBox ID="txtComando1"  placeholder="Comando" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo comando es obligatorio" ControlToValidate="txtComando1" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtComando1" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese Solo Texto!" />
                                    
                                </div>
                                 <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Descripción:</label>
                                <asp:TextBox ID="txtDescripcion1"  placeholder="Descripción" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDescripcion1" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtDescripcion1" ValidationExpression="^[a-zA-Z -_]*$" errormessage="Ingrese Solo Texto!" />
                                    
                                </div>
                                         <div class="form-group">
                               <label for="input" class="col-md-3 control-label">Modelo</label>
                               <asp:DropDownList runat="server" ID="modelos" BorderColor=#0c4566/>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="Seleccione un Modelo!" ControlToValidate="modelos" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>
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






















































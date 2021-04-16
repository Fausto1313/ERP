<%@ Page Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Nivelees.aspx.cs" Inherits="IOT_Nivelees" %>
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
      <a class="navbar-brand" href="#" style="color:azure">Catálogo Niveles</a>
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
    color:lawngreen;
     font-size:20px;
}
         .icon-consultar {
    color:red;
     font-size:20px;
}
    </style>
     <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link"> INSTRUCCIONES: Rellenar botón por botón todo el nivel que el cliente describa, sin dejar algun registro incompleto("Es decir sin terminar hasta NIVEL5"), de lo
contrario se podrían realizar inconsistencias en las descripciones ingresadas.</a>
</div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
     <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
        <div class="row">
           <asp:Label runat="server" AssociatedControlID="Clientes" CssClass="col-md-1 control-label">Cliente</asp:Label>
           <div class="col-md-3">
           <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Clientes" OnSelectedIndexChanged="CargaSitio" AutoPostBack="true"/>
        </div>
         <asp:Label runat="server" AssociatedControlID="Sitio" CssClass="col-md-1 control-label">Sitio</asp:Label>
           <div class="col-md-3">
           <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Sitio"  AutoPostBack="true"/>
        </div>
        </div>
    <br /><br />
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
         AutoGenerateColumns="false" AllowPaging="true"
         DataKeyNames="ID" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nivel 1" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Nombre2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nivel 2" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:BoundField>
             <asp:BoundField DataField="Nombre3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nivel 3" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
             </asp:BoundField>
             <asp:BoundField DataField="Nombre4" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nivel 4" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            
             </asp:BoundField>
             <asp:BoundField DataField="Nombre5" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nivel 5" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                  
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:BoundField>
           <asp:ButtonField CommandName="dispositivosrecord" HeaderText="Asignar Dars" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-inbox icon-success"></i>' />
           <%--  <asp:buttonField  CommandName="dispositivosrecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" Text="Asignar" HeaderText="Asignar Dars" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
        </asp:buttonField>--%>
              <asp:ButtonField CommandName="Consulta" HeaderText="Consulta" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-eye-open icon-consultar"></i>' />
           <%-- <asp:buttonField  CommandName="Consulta" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Consulta" HeaderText="Consulta" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
              </asp:buttonField>--%>
                 </Columns>
  
    </asp:GridView>
                <asp:Button ID="btnAdd" runat="server" OnClick="BtnAddClick" Text=" Nivel 1" CssClass="btn btn-primary"/>
                <asp:Button ID="btnAdd2" runat="server" OnClick="BtnAddClickNivel2" Text="Nivel 2" CssClass="btn btn-primary"/>
              <asp:Button ID="Button5" runat="server" OnClick="BtnAddClickNivel3" Text="Nivel 3" CssClass="btn btn-primary"/>
                <asp:Button ID="Button3" runat="server" OnClick="BtnAddClickNivel4" Text="Nivel 4" CssClass="btn btn-primary"/>
                <asp:Button ID="Button4" runat="server" OnClick="BtnAddClickNivel5" Text="Nivel 5" CssClass="btn btn-primary"/>
            </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
    </div>
    <div>
        <a class="btn btn-danger" href="Configuraciones.aspx" runat="server" role="button">Volver</a>
    </div>
    <!-- Inicia Modal Para Nuevo Registro Nivel1-->
            <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel" style="color:azure">Nuevo Nivel Principal</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                 <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                <tr>
                                    <td>ID: 
                                <asp:Label ID="lblID1" placeholder="ID" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Cliente : 
                                <asp:Label ID="lblCliente1"  placeholder="Cliente" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                    <tr><td>Sitio:
                                <asp:Label ID="txtSitio" runat="server"></asp:Label>
                                </td></tr>
                                    <tr>
                                    <td>Nombre:
                                        <asp:TextBox ID="txtNom1"  placeholder="Nombre" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNom1" ForeColor="Red" ValidationGroup="groupInsert"/>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtNom1" ValidationExpression="^[a-zA-Z0-9 -_]*$" errormessage="Ingrese solo letras!" ValidationGroup="groupInsert"/>
                                    </td>
                                </tr>   
                                 <tr>
                                    <td>Descripción:
                                        <asp:TextBox ID="txtDescripcion"  placeholder="Descripción" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDescripcion" ForeColor="Red" ValidationGroup="groupInsert"/>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtDescripcion" ValidationExpression="^[a-zA-Z0-9 -_]*$" errormessage="Ingrese solo letras y números!" ValidationGroup="groupInsert"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>NOIP:
                                        <asp:TextBox ID="txtNOIP" Visible ="false"  placeholder="NOIP" runat="server"></asp:TextBox>
                                        
                                    </td>
                                </tr> 
                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord" runat="server" OnClick="BtnAddRecordClick" Text="Confirmar" CssClass="btn btn-success" ValidationGroup="groupInsert"/>
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </div>
                    </div>
                    </div>
            </div>
     <!-- Finaliza Modal Para Nuevo Registro Nivel1-->
     <!-- Inicia Modal Para Nuevo Registro Nivel2-->
            <div id="addModalNivel2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel2" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel2">Nuevo Nivel 2</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel2" class="form-group"  runat="server">
                 <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                    <tr>
                                    <td>Nombre:
                                         <asp:TextBox ID="txtNom2"  placeholder="Nombre" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNom2" ForeColor="Red" ValidationGroup="groupInsert2"/>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtNom2" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese solo letras!" ValidationGroup="groupInsert2"/>
                                    </td>
                                </tr>   
                                 <tr>
                                    <td>Descripción:
                                        <asp:TextBox ID="txtDescripcion2"  placeholder="Descripción" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDescripcion2" ForeColor="Red" ValidationGroup="groupInsert2"/>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtDescripcion2" ValidationExpression="^[a-zA-Z0-9 -_]*$" errormessage="Ingrese solo letras y números!" ValidationGroup="groupInsert2"/>
                                    </td>
                                </tr> 
                                 <tr>
                                    <td>Nivel:
                                        <asp:DropDownList runat="server" ID="UbiNiv" />
                                    </td>
                                </tr> 
                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="Button1" runat="server" OnClick="BtnAddRecordClickNivel1" Text="Confirmar " CssClass="btn btn-success" ValidationGroup="groupInsert2"/>
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </div>
                    </div>
                    </div>
            </div>
    <!---gdsghs-->

    <!-- Inicia Modal Para Nuevo Registro Nivel3-->
            <div id="addModalNivel3" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel3" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel3">Nuevo Nivel 3</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel1" class="form-group"  runat="server">
                 <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                    <tr>
                                    <td>Nombre:
                                         <asp:TextBox ID="txtNom3"  placeholder="Nombre" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNom3" ForeColor="Red" ValidationGroup="groupInsert3"/>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator5" Display="Dynamic" controltovalidate="txtNom3" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese solo letras!" ValidationGroup="groupInsert3"/>
                                    </td>
                                </tr>   
                                 <tr>
                                    <td>Descripción:
                                        <asp:TextBox ID="txtDescripcion3"  placeholder="Descripción" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDescripcion3" ForeColor="Red" ValidationGroup="groupInsert3"/>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator6" Display="Dynamic" controltovalidate="txtDescripcion3" ValidationExpression="^[a-zA-Z0-9 -_]*$" errormessage="Ingrese solo letras y números!" ValidationGroup="groupInsert3"/>
                                    </td>
                                </tr> 
                                 <tr>
                                    <td>Nivel:
                                        <asp:DropDownList runat="server" ID="UbiNiv2" />
                                    </td>
                                </tr> 
                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="Button2" runat="server" OnClick="BtnAddRecordClickNivel3" Text="Confirmar " CssClass="btn btn-success" ValidationGroup="groupInsert3"/>
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </div>
                    </div>
                    </div>
            </div>
    <!---gdsghs-->

     <!-- Inicia Modal Para Nuevo Registro Nivel4-->
            <div id="addModalNivel4" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel4" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel4">Nuevo Nivel 4</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel3" class="form-group"  runat="server">
                 <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                    <tr>
                                    <td>Nombre:
                                         <asp:TextBox ID="txtNom4"  placeholder="Nombre" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNom4" ForeColor="Red" ValidationGroup="groupInsert4"/>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator7" Display="Dynamic" controltovalidate="txtNom4" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese solo letras!" ValidationGroup="groupInsert4"/>
                                    </td>
                                </tr>   
                                 <tr>
                                    <td>Descripción:
                                        <asp:TextBox ID="txtDescripcion4"  placeholder="Descripción" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDescripcion4" ForeColor="Red" ValidationGroup="groupInsert4"/>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator8" Display="Dynamic" controltovalidate="txtDescripcion4" ValidationExpression="^[a-zA-Z0-9 -_]*$" errormessage="Ingrese solo letras y números!" ValidationGroup="groupInsert4"/>
                                    </td>
                                </tr> 
                                 <tr>
                                    <td>Nivel:
                                        <asp:DropDownList runat="server" ID="UbiNiv3" />
                                    </td>
                                </tr> 
                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="Button6" runat="server" OnClick="BtnAddRecordClickNivel4" Text="Confirmar " CssClass="btn btn-success" ValidationGroup="groupInsert4"/>
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </div>
                    </div>
                    </div>
            </div>
    <!---gdsghs-->

    <!-- Inicia Modal Para Nuevo Registro Nivel5-->
            <div id="addModalNivel5" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel5" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel5">Nuevo Nivel 5</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel4" class="form-group"  runat="server">
                 <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                    <tr>
                                    <td>Nombre:
                                         <asp:TextBox ID="txtNom5"  placeholder="Nombre" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNom5" ForeColor="Red" ValidationGroup="groupInsert5"/>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator9" Display="Dynamic" controltovalidate="txtNom5" ValidationExpression="^[a-zA-Z ]*$" errormessage="Ingrese solo letras!" ValidationGroup="groupInsert5"/>
                                    </td>
                                </tr>   
                                 <tr>
                                    <td>Descripción:
                                        <asp:TextBox ID="txtDescripcion5"  placeholder="Descripción" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDescripcion5" ForeColor="Red" ValidationGroup="groupInsert5"/>
                                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator10" Display="Dynamic" controltovalidate="txtDescripcion5" ValidationExpression="^[a-zA-Z0-9 -_]*$" errormessage="Ingrese solo letras y números!" ValidationGroup="groupInsert5"/>
                                    </td>
                                </tr> 
                                 <tr>
                                    <td>Nivel:
                                        <asp:DropDownList runat="server" ID="UbiNiv4" />
                                    </td>
                                </tr> 
                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="Button7" runat="server" OnClick="BtnAddRecordClickNivel5" Text="Confirmar " CssClass="btn btn-success" ValidationGroup="groupInsert5"/>
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </div>
                    </div>
                    </div>
            </div>
     <!-- Inicia Modal Para Asignar Ubicacion a Dispositivos-->
            <div id="updModalDars" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="updModalLabel2" style="color:azure">Actualizar Registro Dispositivo</h3>
                </div>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">

                            <table class="table">
                                <tr>
                                    <td>ID de Ubicación de Dispositivo : 
                            <asp:Label ID="lblUbiDis1" runat="server"></asp:Label>
                                    </td>
                                  
                                </tr>
                              
                                <tr>
                                    <td>Dispositivo:
                                    <asp:DropDownList runat="server" ID="Dispositivos" BorderColor=#0c4566 />
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                          
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResultt" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="Button8" runat="server" OnClick="BtnSave_ClickDis" Text="Guardar" CssClass="btn btn-success" />
                            <button  class="btn btn-outline-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
           
                </asp:UpdatePanel>
                    </div>
                    </div>
                    </div>
            </div>
     <!--------------------------------------------------------------------------------------->
      <!-- Inicia Modal Para Consultar-->
            <div id="consultaModal" class="modal fade"  tabindex="-1"  aria-labelledby="delModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="delModalLabel1" style="color:azure">Dispositivos</h3>
                </div>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <div class="modal-body"> 
                            <asp:GridView ID="GridView2" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                      CssClass="table table-hover table-striped" OnPageIndexChanging="OnPageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Dispositivos DARS" SortExpression="Descripción">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                        <div class="modal-footer">
                            
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                       
                    </ContentTemplate>

                </asp:UpdatePanel>
                     </div>
                    </div>
            </div>
      <!-- Inicia Modal Para Consultar-->
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
                            <asp:HiddenField ID="hfID" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnDelete" runat="server"  ValidationGroup="Eliminar" Text="Confirmar" CssClass="btn btn-danger" OnClick="BtnDelete_Click"  />
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



     
</asp:Content>
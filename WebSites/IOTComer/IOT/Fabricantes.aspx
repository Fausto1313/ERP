<%@ Page Language="C#" MasterPageFile="~/IOT/SiteLog.master"AutoEventWireup="true" CodeFile="Fabricantes.aspx.cs" Inherits="Fabricantes" %>
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
      <a class="navbar-brand" href="#" style="color:azure">Catálogo de Fabricantes </a>
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
<a class="alert-link">Este catalogo se podra dar el alta  todas las empresas fabricantes.
  
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
    <!------ validaciones------>
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
            <asp:BoundField DataField="Fabricante" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Fabricante" SortExpression="Fabricante" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Pais" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="País" SortExpression="Pais" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> 
            </asp:BoundField>
          <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-actualizar"></i>' />

<%-- <asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
          <asp:ButtonField CommandName="deleteRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
      <%--  <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
        </asp:buttonField>
      --%>
        </Columns>
  
    </asp:GridView>
          <asp:Button ID="btnAdd" runat="server"  BorderColor=#0c4566 ValidationGroup="Agregar" OnClick="BtnAddClick" Text="Agregar Fabricante" CssClass="btn btn-success" Width="162px" />
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
                                   <label for="input" class="col-md-3 control-label">Fabricante:</label>
                                <asp:TextBox ID="txtFabricante"  placeholder="Fabricante" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo fabricante es obligatorio" ControlToValidate="txtFabricante" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtFabricante" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" />
                                </div>
                                    <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">País:</label>
                                <asp:TextBox ID="txtPais"  placeholder="Pais" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo pais es obligatorio" ControlToValidate="txtPais" ForeColor="Red">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtPais" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" />
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
                    <h3 id="addModalLabel" style="color:azure">Nuevo Fabricante</h3>
                </div>
                      <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                    <label for="inputEmail3" class="col-md-3 control-label">ID</label>
                                <asp:Label ID="txtID1"  runat="server"></asp:Label>
                                     </div>
                                 <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Fabricante:</label>
                                <asp:TextBox ID="txtFabricante1"  placeholder="Fabricante" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo fabricante es obligatorio" ControlToValidate="txtFabricante1" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtFabricante1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="InsertFab"/>
                                </div>
                                    <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">País:</label>
                                <asp:TextBox ID="txtPais1"  placeholder="País" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo pais es obligatorio" ControlToValidate="txtPais1" ForeColor="Red" ValidationGroup="InsertFab">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtPais1" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s.]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="InsertFab"/>
                                    
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
<!--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////-->
    </asp:Content>


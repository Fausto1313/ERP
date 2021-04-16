<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="AdministracionCategoria.aspx.cs" Inherits="IOT_AdministracionCategoria" %>


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
      <a class="navbar-brand" href="#" style="color:azure">Administración Categorias</a>
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
  <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catálogo se podrá realizar el alta de las categorías correspondiente del restaurante .
    <p>
        INSTRUCCION: Para realizar el alta de categorias deberás seleccionar el botón verde y rellenar los campos solicitados.
    </p>
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
       <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center" ><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server" CssClass="body" >
          
     
          <ContentTemplate>
              <br />
                <asp:GridView ID="GridView1" runat="server"  width="940px" HorizontalAlign="Center" AutoGenerateColumns="false" 
                    AllowPaging="true" DataKeyNames="ID" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                  <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="NombreCategoria" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre Categoria" SortExpression="NombreCategoria" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                  <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                         

                        <asp:TemplateField HeaderText="Icono" ItemStyle-VerticalAlign="Top"  ItemStyle-HorizontalAlign="Center" ControlStyle-Width="50px" ControlStyle-Height="50px" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#0c4566">
                            <ItemTemplate   >
                                <image width="50px"  Height="50px" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem, "Icono"))%>"/> 
                            </ItemTemplate>
                        </asp:TemplateField>
                            
                            <asp:BoundField DataField="Orden" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Orden" SortExpression="Orden" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                  <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                              <asp:ButtonField CommandName="updCat" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-cambiar"></i>' />
<%--                             <asp:buttonField  CommandName="updCat"  ButtonType="Button" ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField--%>
                              <asp:ButtonField CommandName="delCat" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
<%--                            <asp:buttonField  CommandName="delCat" ButtonType="Button" ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top"   ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>

                        </Columns>

                    </asp:GridView>

                          <asp:Button ID="btnAdd" runat="server" OnClick="BtnAddClick" ValidationGroup="agregar" Text="Agregar Categoria" CssClass="btn btn-success" BorderStyle="Solid" Width="162px"/>
                        </div>
            <Triggers>
                        
                      
                    </Triggers>
            </ContentTemplate>
        </asp:UpdatePanel>
            <div>
                  <a class="btn btn-danger" href="AdministracionRestaurantes.aspx" runat="server" role="button">Volver</a>
                </div>
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
                                    <td>ID : 
                            <asp:Label ID="txtID" runat="server" BorderColor=#0c4566></asp:Label>
                                    </td>
                                  
                                </tr>
                                <tr>
                                    <td>Nombre Categoria : 
                            <asp:Label  runat="server" BorderColor=#0c4566></asp:Label>
                                        <asp:TextBox runat="server" ID="txtNombreCate"> </asp:TextBox>
                                    </td>
                                  
                                </tr>
                              
                                <tr>
                                    <td>Orden:
                                        <asp:DropDownList ID="Orden2"  runat ="server"></asp:DropDownList>
                                        </td>
                                 </tr>
                                <tr>
                                    <td>Icono:
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="Icono2" OnSelectedIndexChanged="Icono_SelectedIndexChanged2"  AutoPostBack="true" />
                                        <asp:Image runat="server" ID="Image2" Width="100" />
                                    </td>
                                </tr>
                              
                                        <asp:Label runat="server" />
                                    </td>
                        </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="BtnSave_Click" Text="Guardar" CssClass="btn btn-success" />
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
        <!-- Inicia Modal Para Eliminar-->
            <div id="deleteModal" class="modal fade"  tabindex="-1"  aria-labelledby="delModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="delModalLabel" style="color:azure">Eliminar Registro</h3>
                </div>
                <asp:UpdatePanel ID="delCat" runat="server">
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
    <!-- Inicia Modal Para Nuevo Registro-->
            <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">

                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="addModalLabel" style="color:azure">Nueva Categoria</h3>
                </div>
                  
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">
                                
                                <tr>
                                    <td>Nombre de Categoria:
                                        <asp:TextBox runat="server" ID="txtCategoria" placeholder="Insertar Texto" CssClass="form-control" BorderColor="#0c4566" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCategoria" CssClass="text-danger" ErrorMessage="Ingresar texto." ValidationGroup="groupInsert"/>
                                </td>
                                </tr>
                                <tr>
                                    <td>Orden: 
                                        <asp:DropDownList runat="server" ID="Orden" CssClass="form-control" />
                                        
                                
                                           
                                    </td>
                                </tr>
                                
                                   <tr>
                                    <td>Icono:
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="Icono" OnSelectedIndexChanged="Icono_SelectedIndexChanged"  AutoPostBack="true" />
                                        <br />
                                        <asp:Image runat="server" ID="Imagen" Width="100" />
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






</asp:Content>



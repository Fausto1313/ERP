<%@ Page Language="C#" MasterPageFile="~/IOT/SiteLog.master"AutoEventWireup="true" CodeFile="modelos.aspx.cs" Inherits="modelos" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
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
      <a class="navbar-brand" href="#" style="color:azure">Catálogo Modelos</a>
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
<a class="alert-link">Este catalogo se podra dar el alta  todos los modelos o familias correspondientes a los dispositivos.
  
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
                        DataKeyNames="Modelo" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="OnPageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Modelo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripción" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Documento" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Documento" SortExpression="Documento" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
      <asp:BoundField DataField="Fabricante" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Fabricante" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
   <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-actualizar"></i>' />
                  <%--<asp:buttonField  CommandName="updRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-primary"  HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566 Text="Actualizar" /> --%>
         <asp:ButtonField CommandName="descargar" HeaderText="Descargar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-download-alt icon-success"></i>' />
            <%-- <asp:buttonField CommandName="descargar"  ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Descarga" ValidationGroup="Descargar" HeaderText="Descargar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566/>--%>
        </Columns>
  
    </asp:GridView>
<asp:Button ID="btnAdd" runat="server" BorderColor=#0c4566 OnClick="BtnAddClick" Text="Agregar Modelo" class="btn btn-success"  ValidationGroup="validar" Width="162px"/>
              
              </ContentTemplate>
          
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
                
          <div><br /><br />
        <div>
    Seleccione un archivo para subir:<br />
        <asp:FileUpload ID="FlpArchivo" CssClass="btn btn-success" runat="server" BorderColor=#2e7d32 ValidationGroup="Subir" />
        <br />
        <asp:Label ID="lblinformacion"  runat="server" Text=""></asp:Label>
        <br /><br />
             <asp:DropDownList runat="server" ID="Modelo" BorderColor=#0c4566/>
             <asp:Label runat="server" />
                               
        <asp:Button ID="Btnenviar" CssClass="btn btn-danger" runat="server" BorderColor=#2e7d32  Text="Enviar" ValidationGroup="Subir" onclick="Btnenviar_Click" Width="100px" />
        <br /><br />
    </div>
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
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">

                            <table class="table">
                                   <tr>
                                    <td>ID : 
                            <asp:Label ID="lblModelo" runat="server"></asp:Label>
                                    </td>
                                  
                                </tr>
                               
                                <tr>
                                    <td>Documento técnico:
                            <asp:TextBox ID="txtDocumento" runat="server" BorderColor=#0c4566></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo es obligatorio" ControlToValidate="txtDocumento" ForeColor="Red" ValidationGroup="actualizar">
                            </asp:RequiredFieldValidator>    
                                        <asp:Label runat="server" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td>Descripción:
                            <asp:TextBox ID="txtDescripcion" runat="server" BorderColor=#0c4566></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDescripcion" ForeColor="Red" ValidationGroup="actualizar">
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtDescripcion" ValidationExpression="^[a-zA-Z -]*$" errormessage="Ingrese Solo Texto!" />
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                            <tr>
                                    <td>Fabricante:
                                    <asp:DropDownList  runat="server"   ID="Fabricantes" BorderColor=#0c4566>
                                    </asp:DropDownList>  
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="BtnSave_Click" Text="Guardar" CssClass="btn btn-success" ValidationGroup="actualizar" />
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
                            <asp:HiddenField ID="hfidEvento" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnDelete" runat="server" Text="Confirmar" CssClass="btn btn-danger" OnClick="BtnDelete_Click"  />
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
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel" style="color:azure">Nuevo Modelo</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                       <ContentTemplate>
                        <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                             <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Modelo:</label>
                                <asp:TextBox ID="txtModelo1" placeholder="Nombre de Modelo" runat="server" BorderColor=#0c4566></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo modelo es obligatorio" ControlToValidate="txtModelo1" ForeColor="Red" ValidationGroup="groupInsert">
                                           </asp:RequiredFieldValidator>    
                                 <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator3" Display="Dynamic" controltovalidate="txtModelo1" ValidationExpression="^[a-zA-Z0-9-/]*$" errormessage="Ingrese Solo Texto!" ValidationGroup="groupInsert"/>
                                     </div>
                                    <div class="form-group">
                               
                                   <label for="input" class="col-md-3 control-label">Descripción:</label>
                                <asp:TextBox ID="txtDescripcion1"  placeholder="Descripción de Modelo" runat="server" BorderColor=#0c4566></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDescripcion1" ForeColor="Red" ValidationGroup="groupInsert">
                                          </asp:RequiredFieldValidator> 
                                                  <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtDescripcion1" ValidationExpression="^[a-zA-ZáÁéÉíÍóÓúÚ0-9/]*$" />
                                               
                                                
                                           
                                </div>
                                   <div class="form-group">
                                   <label for="input" class="col-md-3 control-label">Fabricante:</label>
                                <asp:DropDownList runat="server" ID="Fabricantes2" BorderColor=#0c4566 />
                                   </div>                                                          
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
          </div>
            <!--Finaliza Modal Para Nuevo Registro-->
<!--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--> 

</asp:Content>
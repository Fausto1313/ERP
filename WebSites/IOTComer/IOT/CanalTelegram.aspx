<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="CanalTelegram.aspx.cs" Inherits="IOT_CanalTelegram" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent2">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
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
      <a class="navbar-brand" href="#" style="color:azure">Crear canal de telegram</a>
    </div>
    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li><!--Inicio de ]Modal
            <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal"> Cliente Nuevo</button>
            fin de modal-->
        </li>  
      </ul>
       <div class="navbar-form navbar-left">
        <div class="form-group"></div>  
      </div>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav> 
      <style>
        .icon-success {
    color:red;
     font-size:20px;
}
        .icon-actalizar{
            color:blue;
            font-size:20px;
        }
 
    </style>
     <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link"> En este catálogo se podrá dar de alta el nombre de canal de telegram para los envios de alertas.</a>
</div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />

<!-- INICIA Catalogo -->
    <div class="form-horizontal">
        <div class="row" >            
             <asp:Label runat="server" AssociatedControlID="Sitio" CssClass="col-md-1 control-label"><b>Sitio</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Sitio" CssClass="form-control" BorderColor=#0c4566  AutoPostBack="true" />
            </div>       
            <asp:Label runat="server"  CssClass="col-md-2 control-label"><b>Canal Telegram</b> </asp:Label> 
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtCanal"  placeholder="Nombre del canal" CssClass="form-control" BorderColor=#0c4566 />
                <asp:RequiredFieldValidator runat="server"   ControlToValidate="txtCanal" CssClass="text-danger" ErrorMessage="El nombre obligatorio." ValidationGroup="groupInsert"/>
            </div>  
            </div>
        <div class="row" >  
            <asp:Label runat="server"  CssClass="col-md-1 control-label"><b>Nombre</b> </asp:Label> 
            <div class="col-md-3">              
                <asp:TextBox runat="server" ID="txtNombre"  placeholder="Area o Departamento" CssClass="form-control" BorderColor=#0c4566 />
                <asp:RequiredFieldValidator runat="server"   ControlToValidate="txtNombre" CssClass="text-danger" ErrorMessage="El nombre del area obligatorio." ValidationGroup="groupInsert"/>
            </div> 
           <div>
               <b>¿Deseas que este canal sea primario?</b>                        
               <asp:checkbox runat="server" ID="primario"/>
           </div>
            </div>
        
      </div>    
    <br/>
  <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">            
          <ContentTemplate>
              <asp:Button runat="server" BorderColor=#2e7d32 OnClick="Agregar_Canal" Text="Agregar" CssClass="btn btn-success" Width="162px" ValidationGroup="groupInsert"/>
<br /><br /><br />   
        <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="CanalTelegram"
          CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand"  OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="CanalTelegram" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre del canal" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>           
            <asp:BoundField DataField="NombreCanal" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Area" SortExpression="Area" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Primario" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Tipo de canal" SortExpression="tipo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                  <asp:ButtonField CommandName="Actualizar" HeaderText="Actualizar Canal" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-actualizar"></i>' />
            <%--<asp:buttonField  CommandName="Actualizar" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Actualizar" HeaderText="Actualizar Canal" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
                  <asp:ButtonField CommandName="Eliminar" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
            <%--<asp:buttonField  CommandName="Eliminar" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar canal" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
        </Columns>   
    </asp:GridView>
            </ContentTemplate>     
          <Triggers>
        </Triggers>
      </asp:UpdatePanel>
    </div>
    <div>
        <a class="btn btn-danger" href="CatalogosAdmin.aspx" runat="server" role="button">Volver</a>
    </div>
 <!---------------------------------------------------------------------------------------------------------------------------------------->  
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
    <!-- FIN MODAL ELIMINAR -->
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
                        <td>Canal de telegram: 
                        <asp:Label ID="lblCanal" runat="server" BorderColor=#0c4566></asp:Label>
                        </td>                                  
                        </tr>
                        <tr>
                        <td>Area del canal:
                        <asp:TextBox ID="txtNombre1" runat="server" BorderColor=#0c4566></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="txtNombre1" ForeColor="Red" >
                        </asp:RequiredFieldValidator>    
                        <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtNombre1" ValidationExpression="^[a-zA-Z0-9 -_]*$" errormessage="Ingrese solo letras y numeros!" />
                        <asp:Label runat="server" />
                        </td>
                        </tr>  
                        <tr>
                        <td>Cambiar tipo de canal:
                        <asp:DropDownList runat="server" ID="Tipo" BorderColor=#0c4566>
                            <asp:ListItem>Primario</asp:ListItem>
                            <asp:ListItem>Secundario</asp:ListItem>
                        </asp:DropDownList>
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






     </asp:Content>
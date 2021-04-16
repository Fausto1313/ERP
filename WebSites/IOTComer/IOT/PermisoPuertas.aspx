<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/IOT/SiteLog.master" CodeFile="PermisoPuertas.aspx.cs" Inherits="IOT_PermisoPuertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
     <br />
     <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure" >Permisos de acceso</a>     
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li>
        </li>       
      </ul>
       <div class="navbar-form navbar-left">
        <div class="form-group">       
        </div>     
      </div>
    </div>
  </div>
</nav> 
    <style>
        .icon-success {
    color:red;
     font-size:20px;
}

    </style>
<!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catálogo se podrá consultar la información del empleado seleccionado atravez del icono verde  y se podrá agregar el permiso del acceso.
       <p>
          INSTRUCCION: Para agregar el acceso deberás selecciona el boton verde y agregar el permiso correspondiente. Una vez agregado los acceso podras ver la información en la tabla.
       </p>
    <p>
        Al agregar un acceso se deberá de tener conectado un DAR en el sitio en dado caso que no mandara un mensaje de error.
    </p>
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
    
  <!-- PANEL DE ROL SELECCIONADO -->
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
   <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
   <asp:GridView runat ="server" ID="GridView1" CssClass="table table-hover table-striped" Width="720px" HorizontalAlign="Center" AutoGenerateColumns="false" >
       <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
           <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre del Usuario" SortExpression="Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           </Columns>
   </asp:GridView>
  <asp:Button ID="btnAdd" runat="server" BorderColor="#0c4566" OnClick="btnAdd_Click" Text="Agregar Permiso" CssClass="btn btn-success" Width="162px"/>
    </div>
    <br />
    <br />
   </ContentTemplate>
   </asp:UpdatePanel>

 <!-- PANEL DE ROLES PERMISOS AGREGADOS -->
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->       
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
          <asp:GridView ID="PermisosDetalle" runat="server" Width="720px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true"
          CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" DataKeyNames="ID">
            <Columns>
             <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID Puerta" SortExpression="Puerta" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                 <asp:ButtonField CommandName="deleteRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
          <%--  <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
            </Columns>
        </asp:GridView>
              </ContentTemplate>
              </asp:UpdatePanel>
              </div>
                <div>
                  <asp:Button class="btn btn-danger" ID="Volver" OnClick="Volver_Click" runat="server" Text="Volver" />
                </div>

    <!-- INICIA MODAL PARA AGREGAR -->
    <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="addModalLabel" style="color:azure">Asignar Permiso</h3>
                </div>
                    <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                    <ContentTemplate>
                         <div class="modal-body">
                         <table class="table">
                          <div class="form-group">
                         <label for="input" class="col-md-3 control-label">ID usuario:</label>
                         <asp:label ID="lblID"  runat="server"></asp:label>                                
                          </div> 
                          <div class="form-group">
                          <asp:Label runat="server" CssClass="col-md-3" ID="lblPuerta" Text="Permiso:" />
                          <asp:DropDownList runat="server" ID="PermisoLista" />
                          </div> 
                             </table>
                             </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord" runat="server" OnClick="BtnAddRecord_Click" Text="Confirmar " CssClass="btn btn-success"  ValidationGroup="groupInsert"/>
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
                <asp:AsyncPostBackTrigger ControlID="PermisosDetalle" EventName="RowCommand" />
                <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                </Triggers>
                </asp:UpdatePanel>
           </div>
           </div>
           </div>
</asp:Content>

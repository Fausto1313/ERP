<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="Telegram.aspx.cs" Inherits="IOT_Telegram" %>

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
      <a class="navbar-brand" href="#"  style="color:azure">Catálogo de Usuarios de Telegram </a>
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
    color:darkgoldenrod;
     font-size:20px;
}
 
    </style>
    <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link"> En este catálogo se podrá realizar la asiganción de cliente a cada uno de los  usuarios registrados en la tabla .</a>
</div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
    <!--- validaciones--->
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate> <br>
                Buscar:&nbsp;<asp:TextBox ID="txtSearch" style="text-align:center" runat="server" OnTextChanged="Search" AutoPostBack="true" ></asp:TextBox>
             
              <br>

    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" OnRowCommand="OnRowCommand" AllowPaging="true"
                        DataKeyNames="ID"  CssClass="table table-hover table-striped" OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="usuario" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre de Usuario" SortExpression="usuario" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
              <asp:ButtonField CommandName="clienterecord" HeaderText="Asignar Cliente" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-user icon-success"></i>' />
               <%--<asp:buttonField  CommandName="clienterecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" Text="Asignar" HeaderText="Asignar Cliente" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                </asp:buttonField>--%>
        </Columns>
    </asp:GridView>
            </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
      <asp:Button ID="btnAdd" runat="server" OnClick="leeSolicitud" Text="Revisar Solicitudes" CssClass="btn btn-success" BorderColor=#0c4566 />
    </div>
    <div>
        <a class="btn btn-danger" href="CatalogosAdmin.aspx" runat="server" role="button">Volver</a>
    </div>
     
      <div id="updModalc" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
               <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="updModalLabel1" style="color:azure">Asignacion de Telegram</h3>
                </div>
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">

                            <table class="table">
                                <tr>
                                    <td>ID : 
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
                            <button  class="btn btn-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
          
                    </Triggers>
                </asp:UpdatePanel>
                    </div>
                    </div>
                    </div>
            </div>
</asp:Content>
    
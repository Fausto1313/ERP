<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="AsignarSimulador.aspx.cs" Inherits="IOT_AsignarSimulador" %>


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
      <a class="navbar-brand" href="#" style="color:azure">Simulador de presencia</a>
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
     <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">En este catálogo se podrá agregar los dispositivos que realizarán la acción atravez del combo y dando clic en el botón verde. Los dispositivos agregados se podrán ver en la tabla</a>
      
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />
<!-- INICIA GRIDVIEW DE TAREA -->
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
        <asp:GridView runat ="server" ID="DetalleTarea" CssClass="table table-hover table-striped" Width="720px" HorizontalAlign="Center" AutoGenerateColumns="false" OnPageIndexChanging="PageIndexChanging">
          <Columns>
             <asp:BoundField DataField="Id" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Id" SortExpression="Id" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
             </asp:BoundField>
             <asp:BoundField DataField="C_Sitio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="sitio" SortExpression="sitio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                 <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
             </asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre de tarea" SortExpression="Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            </Columns>
         </asp:GridView>
       </div>
   </ContentTemplate>
</asp:UpdatePanel>
<!-- TERMINA GRIDVIEW DE TAREA -->
    <hr />
<!-- INICIAN LOS COMBO BOX -->
 <div class="form-horizontal">
    <div class="row">
       <asp:Label runat="server" AssociatedControlID="dis" CssClass="col-md-2 control-label"><b>Dispositivo</b></asp:Label>
         <div class="col-md-3">
           <asp:DropDownList runat="server" ID="dis" CssClass="form-control" BorderColor=#0c4566 AutoPostBack="true"/>
         </div>  
    </div>
  </div>
    <br /><br />
<!-- INICIA Asignacion de DARS -->
      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
         
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
     <asp:Button ID="agregar" runat="server" BorderColor=#2e7d32 OnClick="CreaTarea_Click" Text="Agregar Tarea" CssClass="btn btn-success" Width="162px"/>
              <br /><br /><br />
    <asp:GridView ID="TareasDetalle" runat="server" Width="720px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
          CssClass="table table-hover table-striped" OnPageIndexChanging="GridView2_PageIndexChanging">
        <Columns>
           <asp:BoundField DataField="ID_Simulador" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Dispositivo" SortExpression="Dispositivo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            </Columns>
        </asp:GridView>
              </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="agregar" EventName="Click" />
            </Triggers>
              </asp:UpdatePanel>
              </div>
    <!-- TERMINA Asignacion de DARS -->
                <div>
                  <a class="btn btn-danger" href="SimuladorPresencia.aspx" runat="server" role="button">Volver</a>
                </div>
</asp:Content>
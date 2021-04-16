<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="AsistenteVoz.aspx.cs" Inherits="IOT_AsistenteVoz" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
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
      <a class="navbar-brand" href="#" style="color:azure">Configuración para asistentes de Voz</a>
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
     <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catalogo se podra consultar los comandos para el asistente de voz en la aplicacion ADDAR RISC Y ADDAR CONTROL.
  <p>
      INSTRUCCION: Para ver las url de los comandos deberas dar cli en el icono rojo  y deberás seleccionar los filtros por cliente y sitio para mostrar la informacion
  </p>
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />

    <asp:UpdatePanel ID="upCrudGrid" runat="server" CssClass="body" >
          <ContentTemplate>
    <div class="row">
        <div class="col-md-6">
            <asp:DropDownList runat="server" ID="Cliente" CssClass="form-control" OnSelectedIndexChanged="Cliente_SelectedIndexChanged" AutoPostBack="true" />
        </div>
        <div class ="col-md-6">
            <asp:DropDownList runat="server" ID="Sitio" CssClass="form-control" OnSelectedIndexChanged="Sitio_SelectedIndexChanged" AutoPostBack="true" />
        </div>
    </div>
     <style>
        .icon-success {
    color:orangered;
     font-size:20px;
}
 
    </style>
  
   <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center" ><!--div Margen-->
          
      

                 <%-- Busqueda:&nbsp;<asp:TextBox ID="txtSearch" runat="server" OnTextChanged="Search" AutoPostBack="true"></asp:TextBox>
              <br>
     --%>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true" 
                        DataKeyNames="RISCEI" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="OnPageIndexChanging">
        <Columns>
            <asp:BoundField DataField="RISCEI" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="RISCEI" SortExpression="RISCEI" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Modelo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Modelo" SortExpression="Modelo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
               <asp:ButtonField CommandName="asistente" HeaderText="Liga Asistente" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-volume-up icon-success"></i>' />
           <%-- <asp:buttonField  CommandName="asistente" ButtonType="Button" ControlStyle-CssClass="btn btn-success" Text="Comando" HeaderText="Liga Asistente" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField> --%>
        </Columns>
    </asp:GridView>
     </div>
            </ContentTemplate>
      </asp:UpdatePanel>
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
                    <h3 id="updModalLabel" style="color:azure">Lista de Comandos</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="alert alert-info" role="alert">
        Las ligas mostradas son las que se necesitan añadir para poder configurar un asistente de voz con el servicio IFTTT.
   </div>
                            <table class="table">
                                <tr runat="server" id="uno">
                                    <td><b><asp:Label runat="server" ID="Accion1"/></b>
                            <asp:Label ID="txtuno" ReadOnly="true" BorderColor="#0c4566" runat="server"></asp:Label>
                                    </td>
                                </tr>
                              
                                <tr runat="server" id="dos">
                                    <td><b><asp:Label runat="server" ID="Accion2" /></b>
                            <asp:Label ID="txtdos" ReadOnly="true" BorderColor="#0c4566" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server" id="tres">
                                    <td><b><asp:Label runat="server" ID="Accion3" Visible="false" /> </b>
                            <asp:Label ID="txttres" ReadOnly="true" Visible="false" runat="server" BorderColor="#0c4566"></asp:Label>
                                    </td>
                                  
                                </tr>
                                <tr runat="server" id="cuatro">
                                    <td><b><asp:Label runat="server" ID="Accion4" Visible="false" /> </b>
                            <asp:Label ID="txtcuatro" ReadOnly="true" Visible="false" runat="server" BorderColor="#0c4566"></asp:Label>
                                    </td>
                                  
                                </tr>
                                <tr runat="server" id="cinco">
                                    <td><b><asp:Label runat="server" ID="Accion5" Visible="false" /> </b>
                            <asp:Label ID="txtcinco" ReadOnly="true" Visible="false" runat="server" BorderColor="#0c4566"></asp:Label>
                                    </td>
                                  
                                </tr>
                                <tr runat="server" id="seis">
                                    <td><b><asp:Label runat="server" ID="Accion6" Visible ="false" /> </b>
                            <asp:Label ID="txtseis" Visible="false" ReadOnly="true" runat="server" BorderColor="#0c4566"></asp:Label>
                                    </td>
                                  
                                </tr>
                            
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Entendido" CssClass="btn btn-success" />
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


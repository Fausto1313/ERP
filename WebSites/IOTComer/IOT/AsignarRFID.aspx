<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" Debug="true" CodeFile="AsignarRFID.aspx.cs" Inherits="IOT_AsignarRFID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
<nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure">Registro de Usuarios</a>
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li></li>    
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
<a class="alert-link">Este catálogo se podrá asignar los dispositivos previamente dados de alta en el catálogo de DARS.
    <p>      
    INSTRUCCION: Para agregar lo permisos deberás seleccionar los filtros y dar en el botón Agregar. 
        </p>
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />

 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="form-horizontal">
         <div class="row" >            
             <asp:Label runat="server" AssociatedControlID="Sitio" CssClass="col-md-1 control-label"><b>Sitio</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Sitio" CssClass="form-control" BorderColor=#0c4566 OnSelectedIndexChanged="Carga_select" AutoPostBack="true" />
            </div>
            <asp:Label runat="server" AssociatedControlID="RF" CssClass="col-md-1 control-label"><b>Dispositivo:</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="RF" CssClass="form-control" BorderColor=#0c4566 OnSelectedIndexChanged="Carga_P1" AutoPostBack="true"/>
            </div>
             <asp:Label runat="server" AssociatedControlID="P1" CssClass="col-md-1 control-label"><b>Puerta:</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="P1" CssClass="form-control" BorderColor=#0c4566/>
            </div>
        </div>
    </div>
        <br />
    <div class="container-fluid h-100"> 
    <div class="row w-100 align-items-center">
    <div class="col text-center">
    <asp:Button runat="server" BorderColor=#2e7d32 OnClick="Crea_Regla" Text="Agregar" CssClass="btn btn-success" alig="center" BorderStyle="Solid" Width="155px" ValidationGroup="groupInsert"/> 
    </div>
    </div>
    </div>
    </ContentTemplate>
</asp:UpdatePanel>
<br />

    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="ID"
                        CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>      
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Dispositivo" SortExpression="Dispo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="DescripcionPuerta" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Puerta" SortExpression="Puerta" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
               <asp:ButtonField CommandName="deleteRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
          <%-- <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
           </asp:buttonField>--%>
        </Columns>
    </asp:GridView>
            </ContentTemplate>
          <Triggers>
        </Triggers>
      </asp:UpdatePanel>
    </div> 
    <div>
        <a class="btn btn-danger" href="CatalogoAdminEm.aspx" runat="server" role="button">Volver</a>
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
                <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                </Triggers>
                </asp:UpdatePanel>
           </div>
           </div>
           </div>
    <!-- FIN MODAL ELIMINAR -->



</asp:Content>
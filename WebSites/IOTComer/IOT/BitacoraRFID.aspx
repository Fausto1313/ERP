<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="BitacoraRFID.aspx.cs" Inherits="IOT_BitacoraRFID" %>

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
<!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catálogo se podrás consultar la información de accesos de los clientes de acuerdo al sitio.
    <p>      
    INSTRUCCION: Para mostrar la información en la tabla  deberás seleccionar los filtros . 
</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
     <!-- -->
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
    <div class="form-horizontal">
           <div class="row">
           <asp:Label runat="server" AssociatedControlID="Sitio" CssClass="col-md-1 control-label">Sitio:</asp:Label>
           <div class="col-md-3">
           <asp:DropDownList runat="server" CssClass="form-control" BorderColor=#0c4566  ID="Sitio" AutoPostBack="true" OnSelectedIndexChanged="Sitio_SelectedIndexChanged"/>
           </div>
           <asp:Label runat="server" AssociatedControlID="Cliente" CssClass="col-md-1 control-label">Cliente:</asp:Label>
           <div class="col-md-3">
           <asp:DropDownList runat="server" CssClass="form-control" BorderColor=#0c4566  ID="Cliente" AutoPostBack="true" OnSelectedIndexChanged="Cliente_SelectedIndexChanged"/>
           </div>
           </div>
        <br />
    </div> 

<div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                  AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped" OnPageIndexChanging="PageIndexChanging">
        <Columns>      
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Dispositivo" SortExpression="Dispo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="Fecha" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha" SortExpression="Fecha" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle> <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                
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






  </ContentTemplate>
    </asp:UpdatePanel>
    <br />






</asp:Content>
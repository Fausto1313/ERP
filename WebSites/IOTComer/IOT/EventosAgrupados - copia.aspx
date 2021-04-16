<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventosAgrupados.aspx.cs" MasterPageFile="~/IOT/SiteLog.master" Inherits="IOT_EventosAgrupados" %>
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
      <a class="navbar-brand" href="#" style="color:azure">Eventos Agrupados</a>
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
 .icon-consultar{
    color:darkorange;
     font-size:20px;
}
 .icon-dias {
    color:blue;
     font-size:20px;
}
 .icon-asig {
    color:green;
     font-size:20px;
}
    </style>
<!-- INICIA EVENTOS AGRUPADOS -->
    <!-- Inicia Modal Para Nuevo Registro-->
    
    <div class="form-horizontal">
        <div class="row" >
            
            <asp:Label runat="server"  CssClass="col-md-1 control-label"><b>Nombre</b> </asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="Nombre"  placeholder="Nombre de evento" CssClass="form-control" BorderColor=#0c4566 />
                <asp:RequiredFieldValidator runat="server"   ControlToValidate="Nombre"
                    CssClass="text-danger" ErrorMessage="El nombre obligatorio." ValidationGroup="groupInsert"/>
            </div>   
             <asp:Label runat="server" AssociatedControlID="Sitios" CssClass="col-md-1 control-label"><b>Sitio</b></asp:Label>
                
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Sitios"   CssClass="form-control" BorderColor=#0c4566 />
            </div>
             
            </div>
            
        </div>
    <br /><br /><br />
        
      
        
    <br/>

     <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">            
          <ContentTemplate>

         <asp:Button runat="server" BorderColor=#2e7d32 OnClick="CreaTarea_Click" Text="Agregar Evento" CssClass="btn btn-success" Width="162px"/><br /><br /><br />
   
              <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="Id" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand"  OnPageIndexChanging="PageIndexChanging">
        <Columns>

            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           
            <asp:BoundField DataField="Comando" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Comando" SortExpression="Comando" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="C_Sitio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Sitio" SortExpression="Sitio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                             <asp:ButtonField CommandName="Asignar" HeaderText="Asignar Dispositivo" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-cog icon-dias"></i>' />
             <%--<asp:buttonField  CommandName="Asignar" ButtonType="Button"  ControlStyle-CssClass="btn btn-success" Text="Asignar" HeaderText="Asignar DAR" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
             </asp:buttonField>--%>
             
             <asp:ButtonField CommandName="delRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
           <%-- <asp:buttonField  CommandName="delRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
        </Columns>   
    </asp:GridView>
            </ContentTemplate>
     
          <Triggers>
        </Triggers>


      </asp:UpdatePanel>
    </div>
    <div>
        <a class="btn btn-danger" href="Catalogos.aspx" runat="server" role="button">Volver</a>
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
                            <asp:HiddenField ID="hfs" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="Button2" runat="server"  ValidationGroup="Eliminar" Text="Confirmar" CssClass="btn btn-danger" OnClick="BtnDelete_Click"  />
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                        </div>
                       
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />    
                    </Triggers>
                </asp:UpdatePanel>
                     </div>
                    </div>
            </div>
    <!-- FIN MODAL ELIMINAR -->
 </asp:Content>

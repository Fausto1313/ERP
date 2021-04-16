﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/IOT/SiteLog.master" CodeFile="AgregarDispo.aspx.cs" Inherits="IOT_AgregarDispo" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Dispositivos Agregados</a>
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

    </style>


   <br />
    <!-- INICIA GRIDVIEW DE TAREA -->
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
        <asp:GridView runat ="server" ID="DetalleEvento" CssClass="table table-hover table-striped" Width="720px" HorizontalAlign="Center" AutoGenerateColumns="false" OnPageIndexChanging="PageIndexChanging">
          <Columns>
             <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
             </asp:BoundField>
             <asp:BoundField DataField="C_Sitio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Sitio" SortExpression="Sitio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                 <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
             </asp:BoundField>
                <asp:BoundField DataField="Comando" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Comando" SortExpression="Comando" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            </Columns>
         </asp:GridView>
       </div>
   </ContentTemplate>
</asp:UpdatePanel>
<!-- TERMINA GRIDVIEW DE TAREA -->
    <!-- INICIAN LOS COMBO BOX -->
 <div class="form-horizontal">

    <div class="row">
       <asp:Label runat="server" AssociatedControlID="nivel" CssClass="col-md-2 control-label"><b>Nivel</b></asp:Label>
         <div class="col-md-2">
           <asp:DropDownList runat="server" ID="nivel" CssClass="form-control" BorderColor=#0c4566 AutoPostBack="true" OnSelectedIndexChanged="NivelesSelecionado" />
        </div>

         <asp:Label runat="server" AssociatedControlID="dispos" CssClass="col-md-2 control-label"><b>Dispositivo</b></asp:Label>
       <div class="col-md-2">
             <asp:DropDownList runat="server" ID="dispos" CssClass="form-control" BorderColor=#0c4566 AutoPostBack="true" OnSelectedIndexChanged="DispoSelecionado"/>
        </div>
         <asp:Label runat="server" AssociatedControlID="acciones" CssClass="col-md-2 control-label"><b>Acciones</b></asp:Label>
         <div class="col-md-2">
             <asp:DropDownList runat="server" ID="acciones" CssClass="form-control" BorderColor=#0c4566 AutoPostBack="true">
              <asp:ListItem Text="[Seleccionar]" Value="0" Selected="True"/>
                                       <asp:ListItem Text="ON" Value="ON" />
                                       <asp:ListItem Text="OFF" Value="OFF" />
                                    
              </asp:DropDownList>
              </div>
         </div>  
        </div>
      
    <br /><br />
    <!-- INICIA Asignacion de DARS -->
      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
         
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
     <asp:Button ID="agregar" runat="server" BorderColor=#2e7d32 OnClick="CreaTarea_Click" Text="Agregar Dispositivo" CssClass="btn btn-success" Width="162px"/>
              <br /><br /><br />
               <asp:GridView ID="TareaDetalle" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="Id" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand"  OnPageIndexChanging="GridView2_PageIndexChanging">
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="RISCEI" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Dispositivo" SortExpression="RISCEI" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Accion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Acciones" SortExpression="Accion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField CommandName="delRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
            </Columns>
        </asp:GridView>
              </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="agregar" EventName="Click" />
            </Triggers>
              </asp:UpdatePanel>
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
                            <asp:HiddenField ID="hfss" runat="server" />
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
    <!-- TERMINA Asignacion de DARS -->
                <div>
                  <a class="btn btn-danger" href="EventosAgrupados.aspx" runat="server" role="button">Volver</a>
                </div>
</asp:Content>